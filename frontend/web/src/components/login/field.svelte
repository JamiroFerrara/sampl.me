<script lang="ts">
	export let name = 'default';
	export let handleChange: (event: Event) => any;
	export let value: any;
	export let error: string;
	let name_capitalized = name.charAt(0).toUpperCase() + name.slice(1);
</script>

<label class="label">
	<span>{name_capitalized}</span>
	<input
		id={name}
		{name}
		on:change={handleChange}
		on:blur={handleChange}
		bind:value
		class={'input'}
		type="text"
		placeholder={name_capitalized}
	/>

	{#if error}
		<small>{error}</small>
	{/if}
</label>
