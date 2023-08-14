<script lang="ts">
	import { onMount } from 'svelte';
	import { api } from '../api/api';
	import type { User } from '../api/client';

	let response = false;

	async function refresh() {
		var res = await api.user.login({ email: 'jamiro', password: 'ferrara' });
		response = res.data;
	}

	onMount(async () => {
		await refresh();
	});
</script>

<div on:click={() => refresh()} class="border">cllick</div>

{response}
