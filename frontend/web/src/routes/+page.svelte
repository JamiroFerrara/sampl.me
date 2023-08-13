<script lang="ts">
	import { onMount } from 'svelte';
	import { api } from '../api/api';
	import type { User } from '../api/client';

	let response = false;
	let users: User[] = [];

	async function refresh() {
		var res = await api.user.login({ email: 'asdf', password: 'asdf' });
		var res2 = await api.user.getAllUser();
		response = res.data;
		users = res2.data;
	}

	onMount(async () => {
		await refresh();
	});
</script>

<div on:click={() => refresh()} class="border">cllick</div>

{response}

{#each users as user}
	{user.username}
{/each}
